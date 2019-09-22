import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlService } from '../url-service/url-service.service';
import { Observable } from 'rxjs';
import { Cat } from 'src/shared/models/cat.model';

@Injectable({
  providedIn: 'root'
})
export class CatService {

  private _controllerRoute: string = '/cat';

  constructor(private urlSrv: UrlService,
    private http: HttpClient) { }

  /**
   * @description
   * récupère deux chats pour faire un vote
   */
  public getCandidates(): Observable<Array<Cat>> {
    const url = this.urlSrv.serveurAPI + this._controllerRoute + '/candidates';
    return this.http.get<Array<Cat>>(url);
  }

  public vote(pId: string): Observable<any> {
    const url = this.urlSrv.serveurAPI + this._controllerRoute + '/vote/' + pId;
    return this.http.post(url, null);
  }
}
