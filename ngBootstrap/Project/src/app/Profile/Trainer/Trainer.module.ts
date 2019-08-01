import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainerComponent } from './Trainer.component';
import { FormsModule } from '@angular/forms';
import { SafessPipe } from './safess.pipe';

@NgModule({
   imports: [
      CommonModule,
      FormsModule
   ],
   exports: [
      TrainerComponent
   ],
   declarations: [
      TrainerComponent,
      SafessPipe
   ]
})
export class TrainerModule { }
