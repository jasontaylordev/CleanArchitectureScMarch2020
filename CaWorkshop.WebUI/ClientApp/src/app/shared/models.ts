export class PriorityLevelDto {
  value: number;
  name: string;
}

export class TodoItemDto {
  id: number;
  listId: number;
  title: string;
  note: string;
  done: boolean;
  priority: number;
}

export class TodoListDto {
  id: number;
  title: string;
  items: TodoItemDto[];
}

export class TodosVm {
  priorityLevels: PriorityLevelDto[];
  lists: TodoListDto[];
}

export class CreateTodoListCommand {
  title: string;
}

export class UpdateTodoListCommand {
  id: number;
  title: string;
}

export class CreateTodoItemCommand {
  listId: number;
  title: string;
}

export class UpdateTodoItemCommand {
  id: number;
  listId: number;
  title: string;
  done: boolean;
  priority: number;
  note: string;
}
