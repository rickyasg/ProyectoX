import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { Zoning } from 'app/site/domain/Shared/Zoning'
import { ParametroService } from 'app/site/service/Shared/parametro.service';

@Component({
  selector: 'app-drop-zonificacion',
  templateUrl: './drop-zonificacion.component.html',
  styleUrls: ['./drop-zonificacion.component.css'],
  providers: [ParametroService]
})
export class DropZonificacionComponent implements OnInit {
  
  @Input() Level:0;
  @Input() dependentId:0;
  @Input() LabelText="Seleccione una Opcion";
  @Input() disable=false;


  @Output() zone = new EventEmitter();

  zoning: Zoning[];

  constructor( private parametroService: ParametroService) { }

  ngOnInit() {
  //  this.doGetZoning();

  }

  ngOnChanges(changes: SimpleChanges) 
  {
    this.doGetZoning();
  }

  doGetZoning()
  {
    this.parametroService.getZoning(this.Level, this.dependentId)
    .then (res=>{
        this.zoning=res;
        console.log(this.zoning);
    });
  }
  onChangeZoning($event)
  {
    this.zone.emit($event.value);
  }
 
}
