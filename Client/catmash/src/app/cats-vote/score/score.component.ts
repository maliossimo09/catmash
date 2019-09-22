import { Component, OnInit } from '@angular/core';
import { Cat } from 'src/shared/models/cat.model';
import { CatService } from 'src/shared/services/cat-service/cat.service';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.scss']
})

export class ScoreComponent implements OnInit {

  displayedColumns: string[] = ['score', 'url'];
  cats : Array<Cat> = new Array<Cat>() ;

  constructor(private _catService: CatService) { }

  ngOnInit() {
    this.getCandidates();
  }

   /**
   * @description
   * récupère tous les chats
   */
  private getCandidates(): void {
    this._catService.getAllCats().subscribe((cats: Array<Cat>) => {
      this.cats = cats.sort((one, two) => (one.score > two.score ? -1 : 1));
    },
    error => {
      
    });
  }

}
