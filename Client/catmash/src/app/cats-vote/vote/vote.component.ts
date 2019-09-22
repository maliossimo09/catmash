import { Component, OnInit } from '@angular/core';
import { CatService } from 'src/shared/services/cat-service/cat.service';
import { Cat } from 'src/shared/models/cat.model';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {
   /**
   * @description
   * les chats candidats au vote
   */
  public cats : Array<Cat> = new Array<Cat>();

  constructor(private _catService: CatService) { }

  ngOnInit() {
    this.getCandidates();
  }

   /**
   * @description
   * récupère deux chats pour faire un vote
   */
  private getCandidates(): void {
    this._catService.getCandidates().subscribe((cats: Array<Cat>) => {
      this.cats = cats;
    },
    error => {
      
    });
  }

   /**
   * @description
   * vote pour le ayant l'id correspondant
   */
  private vote(pId: string): void {
    this.cats = new Array<Cat>();
    this._catService.vote(pId).subscribe((response) => {
      this.getCandidates();
    },
    error => {
      
    });
  }

}
