export class PriorityLevel {
  value: number;
  name: string;
}

export class TodoItem {
  id: number;
  listId: number;
  title: string;
  note: string;
  done: boolean;
  priority: number;
}

export class TodoList {
  id: number;
  title: string;
  items: TodoItem[];
}