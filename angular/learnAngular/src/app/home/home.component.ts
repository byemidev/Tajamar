import { Component, inject } from '@angular/core';
import { HousingLocationComponent } from '../housing-location/housing-location.component';
import { CommonModule } from '@angular/common';
import { Housinglocation } from '../housinglocation';
import { HousingService } from '../housing.service';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule, 
    HousingLocationComponent
  ],
  template: `
  <section>
    <form>
      <input type="text" placeholder="Filter by city" #filter>
      <button class="primary"  type="button" (click)="filterResults(filter.value)">Search</button>
    </form>
  </section>
  <section class="results">
  <!-- ngFor suports to static html to iterations or loops in order to access into data collections -->
  <app-housing-location *ngFor="let housingLocation of filteredLocationList" [housingLocation]="housingLocation"></app-housing-location> 
  </section>
  `,
  styleUrl: './home.component.css'
})


export class HomeComponent {
  housingLocationList: Housinglocation[] = [];
  housingService: HousingService = inject(HousingService);
  
  filteredLocationList: Housinglocation[] = [];
  
  filterResults(text: string){ //in our class in order to using into our component we need to building here and theirs instances for objects or data types 
    
    if(!text){
      this.filteredLocationList = this.housingLocationList;
      return;
    }
    
    this.filteredLocationList= this.housingLocationList.filter(
      housingLocation => housingLocation?.city.toLowerCase().includes(text.toLowerCase())
    );
  }


  constructor() {
    this.housingService.getAllHousingLocations().then((housingLocationList: Housinglocation[]) => {
      this.housingLocationList = housingLocationList;
      this.filteredLocationList = housingLocationList;
    });
  }
}

//lesson 14 for adding http communication
// npm install -g json-server
//
