import { Injectable } from '@angular/core';
import { Housinglocation } from './housinglocation';

@Injectable({
  providedIn: 'root'
})


export class HousingService {
  
 //url for data fetching 
 url = 'http://localhost:3000/locations';

  /** In order to use APIs as a service we need fetching
   *  before creating the diferents end-points or methods 
   *  for exporting data*/

  //data fetching
  //Get:  all data
  async getAllHousingLocations(): Promise<Housinglocation[]> { //type script data fetching structure
    const data = await fetch(this.url);
    return await data.json() ?? [];
  }
  //Get: locations by id
  async getHousingLocationById(id: number): Promise<Housinglocation | undefined> {
    const data = await fetch(`${this.url}/${id}`);
    return await data.json() ?? {};
  }

  submitApplication(firstName: string, lastName: string, email: string){
    console.log(`Homes application received: \nfirs-name: ${firstName}  \nlast-name: ${ lastName } \nemail: ${email}   `);
  }

}//end class HousingService

