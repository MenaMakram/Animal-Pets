import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from './../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ImageUploadService {

  constructor(private http: HttpClient) { }
  postFile(fileToUpload: File[]) {
    const endpoint = environment.API_URL + 'UploadImage';
    const formData: FormData = new FormData();
    for (let i = 0; i < fileToUpload.length; i++) {
     formData.append('Image', fileToUpload[i], fileToUpload[i].name);
    }
    return this.http
      .post(endpoint, formData);
  }
}
