import { Component, OnInit } from '@angular/core';
import { CatService } from 'src/shared/services/cat-service/cat.service';
import { Cat } from 'src/shared/models/cat.model';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {
  public cats : Array<Cat> = new Array<Cat>();
  constructor(private _catService: CatService) { }

  ngOnInit() {
    this.getCandidates();
  }

  private getCandidates(): void {
    this._catService.getCandidates().subscribe((cats: Array<Cat>) => {
      this.cats = cats;
    },
    error => {
      
    });
  }

}
