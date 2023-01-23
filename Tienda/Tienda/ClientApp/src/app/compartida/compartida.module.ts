import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormsModule,ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [],
  imports: [    
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ],
  exports:[
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ]
})
export class CompartidaModule { 


}
