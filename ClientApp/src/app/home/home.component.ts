import {Component, Inject, NgModule} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {getBaseUrl} from "../../main";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  firstName = new FormControl('', Validators.required);
  lastName = new FormControl('', Validators.required);
  email = new FormControl('', Validators.required);
  valid = false;

  public onSubmit() {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    const payload = {
      firstName: this.firstName.value,
      lastName: this.lastName.value,
      email: this.email.value
    }
    console.log(JSON.stringify(payload))
    this.http.put<any>(getBaseUrl() + 'form', JSON.stringify(payload), httpOptions).subscribe(result => {
      console.log(result);
    })
  }
}
