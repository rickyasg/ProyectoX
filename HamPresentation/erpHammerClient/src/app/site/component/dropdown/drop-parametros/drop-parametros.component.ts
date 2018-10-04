import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Parameters } from '../../../domain/Shared/Parameters';
import { SelectItem } from 'primeng/primeng';
import {ParametroService} from '../../../service/Shared/parametro.service';

@Component({
  selector: 'app-drop-parametros',
  templateUrl: './drop-parametros.component.html',
  styleUrls: ['./drop-parametros.component.css'],
  providers: [ParametroService]
})
export class DropParametrosComponent implements OnInit {

    @Input() GroupId=0; 
    @Input() disable = false;
    @Input() LabelText="Seleccione una Opcion";
    @Input() Filter=false;

    @Output() Parameter = new EventEmitter();

    parameters: Parameters[];
 

  constructor(private parametroService: ParametroService) { }

  ngOnInit() {
    
    this.doGetParameters();
  }
  doGetParameters()
  {
    this.parametroService.getParametro(this.GroupId)
    .then (res=>{
        this.parameters=res;
    });
  }
  onChangeParameter($event)
  {
    this.Parameter.emit($event.value);
  }


}
