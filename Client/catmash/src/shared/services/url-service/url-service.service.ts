import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  //#region ATTRIBUTS

  /*===================================================================
                              ATTRIBUTS
  =====================================================================*/

  private _serveurAPI: string;


  //#endregion
  
  //#region METHODES
  /*===================================================================
                              METHODES
  =====================================================================*/

  constructor() {
    this._serveurAPI = environment.serveurAPI;
   }

  //#region ------------------------------- GETTERS AND SETTERS -------------------------------

  public get serveurAPI(): string{
    return this._serveurAPI;
  }

  //#endregion

  //#endregion

}
