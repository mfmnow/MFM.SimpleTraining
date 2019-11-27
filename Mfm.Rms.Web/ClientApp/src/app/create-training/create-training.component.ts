import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIRequestResult } from '../_models/APIRequestResult';
import { TrainingModel } from '../_models/TrainingModel';

@Component({
  selector: 'create-training',
  templateUrl: './create-training.component.html',
})
export class CreateTrainingComponent {
  public ComponentModel: TrainingModel = new TrainingModel();
  public Loading: boolean = false;
  public Success: boolean = false;
  public Error: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  public CreateTraining(): void {
    this.Loading = true;
    this.Error = "";
    this.http.post<APIRequestResult>(this.baseUrl + 'api/training/create', this.ComponentModel)
      .subscribe(
        res => {
          this.Loading = false;
          if (res.success) {
            this.Success = true;
          }
          else {
            this.Error = res.errorMessage;
          }
        },
        err => {
          this.Loading = false;
          this.Error = "Error occured";
        }
      );
    }

    public Reset() {
        this.ComponentModel = new TrainingModel();
        this.Success = false;
    }
}
