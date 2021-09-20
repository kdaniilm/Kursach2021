import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CharacteristicModel } from 'src/app/models/characteristicModel';

@Component({
  selector: 'app-add-characteristics',
  templateUrl: './add-characteristics.component.html',
  styleUrls: ['./add-characteristics.component.css']
})
export class AddCharacteristicsComponent implements OnInit {

  public characteristicModel = new CharacteristicModel();

  // public characteristicFormGroup = new FormGroup({
  //   characteristicName: new FormControl('', Validators.required),
  //   characteristicValue: new FormControl('', Validators.required)
  // });

  constructor() { }

  ngOnInit(): void {
  }

}
