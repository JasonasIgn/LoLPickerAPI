import { Component, OnInit, OnDestroy } from '@angular/core';
import { GeneralData } from '../../models/generaldata.model';
import { Observable, BehaviorSubject, Subscription } from 'rxjs/';
import { GeneralDataService } from '../../services/general.service';
import { MatchService } from '../../services/match.service';
import { MatchModel } from '../../models/match.model';

@Component({
  selector: 'app-collect-data',
  templateUrl: './collect-data.component.html',
  styleUrls: ['./collect-data.component.css']
})
export class CollectDataComponent implements OnInit, OnDestroy {


  generalData: GeneralData = new GeneralData;
  loading: boolean = false;
  notice: number = 0;
  newTeam: boolean = true;
  updateTeam: boolean = true;
  notFound: boolean = true;
  badMap: boolean = true;
  notDraft: boolean = true;
  lowRank: boolean = true;
  loops: number = 0;

  loopSubscription: Subscription;


  constructor(private generalDataService: GeneralDataService,
                private matchService: MatchService) { }

  ngOnInit() {

    this.generalDataService.getGeneralData(1).subscribe((response: GeneralData) => {
      this.generalData = response;
    });

  }
  ngOnDestroy()
  {

  }
  
  Loop(api:string, loops:number)
  {
    this.loading = true;
    this.loops = loops;
    if (this.loops > 0)
    {
      this.loopSubscription = Observable.interval(1200).subscribe(x => {
        this.ExtractData(api);
        this.loops--;
        if (this.loops <= 0)
        {
          this.loading = false;
          this.loopSubscription.unsubscribe();
        } 
      });
    }
  }
  ExtractData(api: string)
  {
      this.updateTeam = true;
      this.newTeam = true;
      this.notFound = true;
      this.badMap = true;
      this.notDraft = true;
      this.lowRank = true;

      this.loading = true;
        this.matchService.SaveMatchData(this.generalData.currentMatchId, api).subscribe((res: any) => {
          console.log(res);
          if (res == 0)
          {
            this.updateTeam = true;
            this.newTeam = false;
            this.notFound = true;
            this.badMap = true;
            this.notDraft = true;
            this.lowRank = true;
            this.generalData.totalTeamCombinations = this.generalData.totalTeamCombinations + 1;
          } 
          else if (res == 1)
          {
            this.updateTeam = false;
            this.newTeam = true;
            this.notFound = true;
            this.notDraft = true;
            this.badMap = true;
            this.lowRank = true;
          }
          else if (res == 2)
          {
            this.updateTeam = true;
            this.newTeam = true;
            this.notFound = true;
            this.notDraft = false;
            this.badMap = true;
            this.lowRank = true;
          }
          else if (res == 3)
          {
            this.updateTeam = true;
            this.newTeam = true;
            this.notFound = true;
            this.badMap = false;
            this.notDraft = true;
            this.lowRank = true;
          }
          else if (res == 4)
          {
            this.updateTeam = true;
            this.newTeam = true;
            this.notFound = true;
            this.badMap = true;
            this.notDraft = true;
            this.lowRank = false;
          }
          else if (res == 404)
          {
            this.updateTeam = true;
            this.newTeam = true;
            this.notFound = false;
            this.notDraft = true;
            this.badMap = true;
            this.lowRank = true;
          }
          
          
        });
        this.generalData.currentMatchId = this.generalData.currentMatchId + 1;
          this.generalDataService.updateGeneralData(this.generalData).subscribe((res: any) => {
          
            console.log("Aaa");
            
          });
        
  }

  sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
      if ((new Date().getTime() - start) > milliseconds){
        break;
      }
    }
  }

}