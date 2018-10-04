import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DenunciasService } from 'app/site/service/Denuncias/denuncias.service'

@Component({
  selector: 'app-vw-listados',
  templateUrl: './vw-listados.component.html',
  styleUrls: ['./vw-listados.component.css'],
  providers: [DenunciasService]
})
export class VwListadosComponent implements OnInit {
  date1: Date;
  Usuario:any;
  lista:any;
  hideElement:any;
  _listado: any[];
  constructor(private router: Router,private route: ActivatedRoute,private denunciasService:DenunciasService

  ) { }

  ngOnInit() {

    this.denunciasService.getDenuncias().then(res=>{
      // debugger;
      this._listado=res;
    })
  }
  addDenuncias() {
    this.router.navigate(['/master/form-denuncias/']);
  }  

}
