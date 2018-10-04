import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SelectItem } from 'primeng/primeng';

@Component({
  selector: 'app-deportes',
  templateUrl: './deportes.component.html',
  styleUrls: ['./deportes.component.css'],
})
export class DeportesComponent implements OnInit {
  @Input() eventoId = 1;
  @Input() disable = false;

  @Output() deporte = new EventEmitter();
  deportes: SelectItem[];
  @Input() selectedValue: string;
  language: any;

  constructor(
    private deporteService: any
  ) {
  }
  ngOnInit() {
    this.doGetDeportes();
  }
  doGetDeportes() {
    this.deporteService
      .getDeportes(this.eventoId)
      .then(res => {
        this.deportes = res.map(item => {
          return {
            value: item.DeporteId, label: item.DeporteDescripcion
          };
        });
      });
  }
  onChangeDeporte($event) {
    this.deporte.emit($event.value);
  }
}
