import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { TodoItem, TodoList } from '../shared/models';
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

  getTodoLists(): Observable<TodoList[]> {
    const url = this.baseUrl;

    return this.http.get<TodoList[]>(url);
  }

  postTodoList(list: TodoList): Observable<TodoList> {
    const url = this.baseUrl;

    return this.http.post<TodoList>(url, list);
  }

  putTodoList(id: number, list: TodoList): Observable<TodoList> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.put<TodoList>(url, list);
  }

  deleteTodoList(id: number): Observable<TodoList> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.delete<TodoList>(url);
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

  postTodoItem(item: TodoItem): Observable<TodoItem> {
    const url = this.baseUrl;
    console.log(url);
    return this.http.post<TodoItem>(url, item);
  }

  putTodoItem(id: number, item: TodoItem): Observable<TodoItem> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.put<TodoItem>(url, item);
  }

  deleteTodoItem(id: number): Observable<TodoItem> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.delete<TodoItem>(url);
  }
}