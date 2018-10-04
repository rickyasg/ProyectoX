import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { Office } from 'app/site/domain/Shared/office'
import { ParametroService } from 'app/site/service/Shared/parametro.service';
import { debug } from 'util';

@Component({
  selector: 'app-drop-offices',
  templateUrl: './drop-offices.component.html',
  styleUrls: ['./drop-offices.component.css'],
  providers: [ParametroService]
})
export class DropOfficesComponent implements OnInit {

  @Input() Level:0;
  @Input() dependentId:0;
  @Input() LabelText="Seleccione una Opcion";
  @Input() disable=false;
  @Input() Filter=false;

  @Output() office = new EventEmitter();

  offices:Office[];

  constructor(private parametroService: ParametroService) { }

  ngOnInit() {
    this.doGetOffices();
  }

  ngOnChanges(change:SimpleChanges)
  {
    this.doGetOffices();
  }
doGetOffices()
  {
    this.parametroService.getOffices(this.Level, this.dependentId)
    .then (res=>{
        this.offices=res;
        // console.log(this.zoning);
    });
  }
  onChangeParameter($event)
  {
    this.office.emit($event.value);
  }
}
