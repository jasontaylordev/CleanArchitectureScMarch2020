import { Component, TemplateRef, OnInit } from '@angular/core';
import { faPlus, faEllipsisH } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { TodoList, TodoItem, PriorityLevel } from '../shared/models';
import { TodoListsClient, TodoItemsClient } from '../services/data.service';

@Component({
  selector: 'app-todo-component',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {
  debug = true;
  lists: TodoList[];

  priorityLevels: PriorityLevel[] = [
    { value: 0, name: 'None' },
    { value: 1, name: 'Low' },
    { value: 2, name: 'Medium' },
    { value: 3, name: 'High' }
  ];

  selectedList: TodoList;
  selectedItem: TodoItem;
  newListEditor: any = {};
  listOptionsEditor: any = {};
  itemDetailsEditor: any = {};
  newListModalRef: BsModalRef;
  listOptionsModalRef: BsModalRef;
  deleteListModalRef: BsModalRef;
  itemDetailsModalRef: BsModalRef;
  faPlus = faPlus;
  faEllipsisH = faEllipsisH;

  constructor(
    private listsClient: TodoListsClient,
    private itemsClient: TodoItemsClient,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.listsClient.getTodoLists().subscribe(
      result => {
        this.lists = result;
        if (this.lists.length) {
          this.selectedList = this.lists[0];
        }
      },
      error => console.error(error)
    );
  }

  // Lists
  remainingItems(list: TodoList): number {
    return list.items.filter(t => !t.done).length;
  }

  showNewListModal(template: TemplateRef<any>): void {
    this.newListModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById('title').focus(), 250);
  }

  newListCancelled(): void {
    this.newListModalRef.hide();
    this.newListEditor = {};
  }

  addList(): void {
    const list = {
      id: 0,
      title: this.newListEditor.title,
      items: []
    } as TodoList;

    this.listsClient.postTodoList(list).subscribe(
      result => {
        list.id = result.id;
        this.lists.push(list);
        this.selectedList = list;
        this.newListModalRef.hide();
        this.newListEditor = {};
      },
      error => {
        const errors = JSON.parse(error.response);

        if (errors && errors.Title) {
          this.newListEditor.error = errors.Title[0];
        }

        setTimeout(() => document.getElementById('title').focus(), 250);
      }
    );
  }

  showListOptionsModal(template: TemplateRef<any>) {
    this.listOptionsEditor = {
      id: this.selectedList.id,
      title: this.selectedList.title
    };

    this.listOptionsModalRef = this.modalService.show(template);
  }

  updateListOptions() {
    const list = this.listOptionsEditor as TodoList;
    this.listsClient.putTodoList(this.selectedList.id, list).subscribe(
      () => {
        (this.selectedList.title = this.listOptionsEditor.title),
          this.listOptionsModalRef.hide();
        this.listOptionsEditor = {};
      },
      error => console.error(error)
    );
  }

  confirmDeleteList(template: TemplateRef<any>) {
    this.listOptionsModalRef.hide();
    this.deleteListModalRef = this.modalService.show(template);
  }

  deleteListConfirmed(): void {
    this.listsClient.deleteTodoList(this.selectedList.id).subscribe(
      () => {
        this.deleteListModalRef.hide();
        this.lists = this.lists.filter(t => t.id !== this.selectedList.id);
        this.selectedList = this.lists.length ? this.lists[0] : null;
      },
      error => console.error(error)
    );
  }

  // Items
  showItemDetailsModal(template: TemplateRef<any>, item: TodoItem): void {
    this.selectedItem = item;
    this.itemDetailsEditor = {
      ...this.selectedItem
    };

    this.itemDetailsModalRef = this.modalService.show(template);
  }

  updateItemDetails(): void {
    const item = this.itemDetailsEditor as TodoItem;
    this.itemsClient.putTodoItem(this.selectedItem.id, item).subscribe(
      () => {
        if (this.selectedItem.listId !== this.itemDetailsEditor.listId) {
          this.selectedList.items = this.selectedList.items.filter(
            i => i.id !== this.selectedItem.id
          );
          const listIndex = this.lists.findIndex(
            l => l.id === this.itemDetailsEditor.listId
          );
          this.selectedItem.listId = this.itemDetailsEditor.listId;
          this.lists[listIndex].items.push(this.selectedItem);
        }

        this.selectedItem.priority = this.itemDetailsEditor.priority;
        this.selectedItem.note = this.itemDetailsEditor.note;
        this.itemDetailsModalRef.hide();
        this.itemDetailsEditor = {};
      },
      error => console.error(error)
    );
  }

  addItem() {
    const item = {
      id: 0,
      listId: this.selectedList.id,
      priority: this.priorityLevels[0].value,
      title: '',
      done: false
    } as TodoItem;

    this.selectedList.items.push(item);
    const index = this.selectedList.items.length - 1;
    this.editItem(item, 'itemTitle' + index);
  }

  editItem(item: TodoItem, inputId: string): void {
    this.selectedItem = item;
    setTimeout(() => document.getElementById(inputId).focus(), 100);
  }

  updateItem(item: TodoItem, pressedEnter: boolean = false): void {
    const isNewItem = item.id === 0;

    if (!item.title.trim()) {
      this.deleteItem(item);
      return;
    }

    if (item.id === 0) {
      this.itemsClient
        .postTodoItem({ ...item, listId: this.selectedList.id })
        .subscribe(
          result => {
            item.id = result.id;
          },
          error => console.error(error)
        );
    } else {
      this.itemsClient.putTodoItem(item.id, item).subscribe(
        () => console.log('Update succeeded.'),
        error => console.error(error)
      );
    }

    this.selectedItem = null;

    if (isNewItem && pressedEnter) {
      this.addItem();
    }
  }

  deleteItem(item: TodoItem) {
    if (this.itemDetailsModalRef) {
      this.itemDetailsModalRef.hide();
    }

    if (item.id === 0) {
      const itemIndex = this.selectedList.items.indexOf(this.selectedItem);
      this.selectedList.items.splice(itemIndex, 1);
    } else {
      this.itemsClient.deleteTodoItem(item.id).subscribe(
        () =>
          (this.selectedList.items = this.selectedList.items.filter(
            t => t.id !== item.id
          )),
        error => console.error(error)
      );
    }
  }
}
