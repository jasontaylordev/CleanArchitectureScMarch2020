import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { TodosVm, CreateTodoListCommand, UpdateTodoListCommand,
  CreateTodoItemCommand, UpdateTodoItemCommand } from '../shared/models';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable({
  providedIn: 'root'
})
export class TodoListsClient {
  private http: HttpClient;
  private baseUrl: string;

  constructor(@Inject(HttpClient) http: HttpClient,
    @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    this.http = http;
    this.baseUrl = baseUrl ? `${baseUrl}/api/TodoLists` : '';
  }

  getTodoLists(): Observable<TodosVm> {
    const url = this.baseUrl;

    return this.http.get<TodosVm>(url);
  }

  postTodoList(command: CreateTodoListCommand)
    : Observable<number> {
    const url = this.baseUrl;

    return this.http.post<number>(url, command);
  }

  putTodoList(id: number, command: UpdateTodoListCommand)
    : Observable<string> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.put<string>(url, command);
  }

  deleteTodoList(id: number): Observable<string> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.delete<string>(url);
  }
}

@Injectable({
  providedIn: 'root'
})
export class TodoItemsClient {
  private http: HttpClient;
  private baseUrl: string;

  constructor(@Inject(HttpClient) http: HttpClient,
    @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    this.http = http;
    this.baseUrl = baseUrl ? `${baseUrl}/api/TodoItems` : '';
  }

  postTodoItem(command: CreateTodoItemCommand): Observable<number> {
    const url = this.baseUrl;

    return this.http.post<number>(url, command);
  }

  putTodoItem(id: number, command: UpdateTodoItemCommand)
    : Observable<string> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.put<string>(url, command);
  }

  deleteTodoItem(id: number): Observable<string> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.delete<string>(url);
  }
}
