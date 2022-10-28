import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private readonly backendURL: string;

  constructor(private http: HttpClient) {
    this.backendURL = environment.api.baseUrl;
  }

  public get<T = any>(url: string, urlParams?: any): Observable<T> {
    const options = ApiService.getOptions(urlParams);
    options.headers = ApiService.getHeaders();
    return this.http.get<T>(`${this.backendURL}${url}`, options);
  }

  public patch<T = any>(url: string, data: any): Observable<T> {
    const options = ApiService.getOptions();
    options.headers = ApiService.getHeaders();
    return this.http.patch<T>(`${this.backendURL}${url}`, data, options);
  }

  public delete<T = any>(url: string, urlParams?: any): Observable<T> {
    const options = ApiService.getOptions(urlParams);
    options.headers = ApiService.getHeaders();
    return this.http.delete<T>(`${this.backendURL}${url}`, options);
  }

  public deleteWithBody<T = any>(url: string, urlParams?: any, body?: any): Observable<T> {
    let options = ApiService.getOptions(urlParams);
    options.headers = ApiService.getHeaders();
    if (body != null) {
      options = {
        ...options,
        body: body,
      } as any;
    }
    return this.http.delete<T>(`${this.backendURL}${url}`, options);
  }

  public post<T = any>(
    url: string,
    data: any,
    opts?: { headers?: Record<string, string | string[]> }
  ): Observable<T> {
    const options = ApiService.getOptions();
    options.headers = ApiService.getHeaders(opts?.headers);
    return this.http.post<T>(`${this.backendURL}${url}`, data, options);
  }

  public postFormDataWithProgress<T = any>(
    url: string,
    formData: FormData
  ): Observable<HttpEvent<T>> {
    return this.http.post<T>(`${this.backendURL}${url}`, formData, {
      reportProgress: true,
      observe: 'events',
    });
  }

  public put<T = any>(url: string, data: any, urlParams?: any): Observable<T> {
    const options = ApiService.getOptions(urlParams);
    options.headers = ApiService.getHeaders();
    return this.http.put<T>(`${this.backendURL}${url}`, data, options);
  }

  private static getOptions(urlParams?: any): { params?: HttpParams; headers?: HttpHeaders } {
    const options: { params?: HttpParams; headers?: HttpHeaders } = {};
    if (urlParams) {
      options.params = new HttpParams({ fromObject: urlParams });
    }
    return options;
  }

  private static getHeaders(additionalHeaders?: Record<string, string | string[]>): HttpHeaders {
    const headers = {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
      'Access-Control-Allow-Headers': 'Origin, Content-Type, X-Auth-Token',
      ...additionalHeaders,
    };
    return new HttpHeaders(headers);
  }
}
