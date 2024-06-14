import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { GeneroPipe } from './pipes/genero.pipe';
import { MatToolbar, MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { RouterModule } from '@angular/router';
import { EnderecoPipe } from './pipes/endereco.pipe';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ClienteComponent } from './components/cliente-list/cliente.component';
import { ClienteDetailsComponent } from './components/cliente-details/cliente-details.component';
import { ClienteAddEditComponent } from './components/cliente-add-edit/cliente-add-edit.component';
import { provideHttpClient } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    ClienteDetailsComponent,
    ClienteAddEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    MatTableModule,
    CommonModule,
    GeneroPipe,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
    MatPaginator,
    MatPaginatorModule,
    MatToolbar,
    MatCardModule,
    MatExpansionModule,
    EnderecoPipe,
    MatButtonModule,
    MatDatepickerModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
    MatToolbarModule,
    MatDialogModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTableModule,
    MatPaginatorModule,
    MatSnackBarModule,
    MatIconModule,
  ],
  providers: [provideHttpClient(), provideAnimations()],
  bootstrap: [AppComponent]
})
export class AppModule { }
