import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  ngOnInit(): void {
  }

  title = 'dropzone';
  
    files: File[] = [];
  
    constructor(private http: HttpClient) { }
  
    onSelect(event: { addedFiles: any; }) {
        console.log(event);
        this.files.push(...event.addedFiles);
  
        const formData = new FormData();
    
        for (var i = 0; i < this.files.length; i++) { 
          formData.append("file[]", this.files[i]);
        }
   
        this.http.post('http://localhost:8001/upload.php', formData)
        .subscribe(res => {
           console.log(res);
           alert('Uploaded Successfully.');
        })
    }
  
    onRemove(event: File) {
        console.log(event);
        this.files.splice(this.files.indexOf(event), 1);
    }

}
