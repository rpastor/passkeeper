import { Component, Injectable, OnInit } from '@angular/core';
import { PkServiceInfo } from './PkServiceInfo';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
@Injectable()
export class AppComponent implements OnInit {
  title = 'app works!';
  services: PkServiceInfo[];

  private baseUrl = 'http://localhost:5000';
  
  constructor(private http: Http) {}

  ngOnInit() {
    this.getPasswordList()
      .subscribe( (response: PkServiceInfo[]) => {
        this.services = response
      });
  }

  private getPasswordList() : Observable<PkServiceInfo[]> {
    var url = this.baseUrl + '/api/passwords';
      
      return this.http
                  .get(url)                            
                  .map(this.extractServiceInfoList);
    
  }

  private extractServiceInfoList(res: Response) : PkServiceInfo[] {
      let body = res.json();
      let result: PkServiceInfo[] = [];

      body.forEach(s => {
        var item = new PkServiceInfo();
        item.name = s;

        result.push(item);
      });
      return result;
  }  
}
