import { Component, OnInit } from '@angular/core';
import { DenunciasService } from '../../../service/Denuncias/denuncias.service';
import { SelectItem } from 'primeng/primeng';
import { TypeCrimen } from '../../../domain/Denuncias/TypeCrimen'
import {Zoning} from 'app/site/domain/Shared/Zoning';
import { Office } from 'app/site/domain/Shared/office'
import { DropZonificacionComponent } from '../../../component/dropdown/drop-zonificacion/drop-zonificacion.component';
import { Complaints } from 'app/site/domain/Denuncias/Complaints';
import { Parameters } from '../../../domain/Shared/Parameters';
import { ActivatedRoute, Router } from '@angular/router';
import { Message } from 'primeng/primeng';
import { GroupTypeCrimen } from '../../../domain/Denuncias/GroupTypeCrimen';
import {SelectItemGroup} from 'primeng/primeng';
// import { ValueTransformer } from '@angular/compiler/typings/src/util';


@Component({
  selector: 'app-vw-formulario',
  templateUrl: './vw-formulario.component.html',
  styleUrls: ['./vw-formulario.component.css'],
  providers: [DenunciasService]
})
export class VwFormularioComponent implements OnInit {
  
  // _Delitos: GroupTypeCrimen[];
  _Delitos: SelectItemGroup[];
  _department: Zoning;
  _province: Zoning;
  _municipality: Zoning;
  _zone: Zoning;
  FechaNac:Date;
  _office: Office;
  text:string;
  _complaint:Complaints;
  _hideDenuncia:boolean=true;
  _hidehechos:boolean=true;
  msgs: Message[] = [];
  country: any;

  countries: any[];
  constructor(private denunciasService:DenunciasService,private router: Router,private route: ActivatedRoute
) { }

  ngOnInit() {
    this._department= new Zoning();
    this._province= new Zoning();
    this._municipality= new  Zoning()
    this._zone= new  Zoning()
    this._office= new Office();
    this.FechaNac= new Date();
    this._complaint= new Complaints();
    
  this.denunciasService.getGroupTypeCrimen("").then(
    res=>{
      debugger;
      this._Delitos=res;
      console.log(this._Delitos);
// var data1=res.map(i => {
//         return {
//            label:i.Name
//            , items: i.TypeCrimens.map(function (val){ 
//             console.log(val);
//             var obj={

//                value:val.TypeCrimeId
//                ,label:val.Crime
//              };
//              console.log(obj)
//             return obj;
//            })
           
//           }
//       });
//       debugger;
//       console.log(data1);
    }
  );
    
  }
  SelectParametro($event,tipo)
  {
    var p= $event as Parameters
    switch (tipo) {
      case 6:
        this._complaint.OrganizationId=p.ParameterId
        break;    
        case 1:
        this._complaint.Denunciante.ParameterExtent=p.ParameterId
        break; 
        case 4:
        this._complaint.Denunciante.ParameterGender=p.ParameterId
        break; 
        case 5:
        this._complaint.Denunciante.ParameterCivilStatus=p.ParameterId
        break;  
        case 2:
        this._complaint.Denunciante.ParameterNationality=p.ParameterId
        break;  
        case 3:
        this._complaint.ParameterTypeViaId=p.ParameterId
        break;        
      default:
        break;
    }
    console.log($event);
  }
  SelectDepartment($event)
  {

    this._department= $event as Zoning;
  }
  SelectProvince($event)
  {
    this._province=$event as Zoning;
  }
  SelectMunicipio($event)
  {
    this._municipality=$event as Zoning;
  }
  SelectZona($event)
  {
    this._zone=$event as Zoning;
    this._complaint.ZoningId=this._zone.ZoningId;
  }

  SelectOfficeDepartamento($event)
  {
    this._office=$event as Office;
  }
  SelectOfficeComiseria($event)
  {
    var t= $event as Office;
    this._complaint.OfficeId=t.OfficeId;
  }
  onSaveCaso($event)
  {
    // console.log($event);
    if(this._complaint.ComplaintId===0)
    {
    this.denunciasService.setDenunciaPasoUno(this._complaint).subscribe(res=>
      {
          const resp = res.json();
          if(resp>0)
          {
            this._complaint.ComplaintId=resp;
            this.showMessage('Se registro correctamento, ahora registre datos de denunciantes ', 'info', 'Mensaje');

            this._hideDenuncia=false;
          }
      });
    }
  }

  onSaveDenunciante($event)
  {
    // console.log($event);
    console.log(this._complaint);
    if(this._complaint.ComplaintId!==0)
    {
    this.denunciasService.setDenunciaPasoUno(this._complaint).subscribe(res=>
      {
          const resp = res.json();
          if(resp>0)
          {
            this._complaint.Denunciante.ComplainantId=resp;
            this._hidehechos=false;
            this.showMessage('Se registro correctamento, ahora registre datos de los Hechos', 'info', 'Mensaje');
          }
      });
    }
  }
  onSaveHechos($event)
  {
    // console.log($event);
    console.log(this._complaint);
    this.denunciasService.setDenunciaPasoDos(this._complaint).subscribe(res=>
      {
          const resp = res.json();
          if(resp>0)
          {
            this._complaint.ComplaintId=resp;
            this.showMessage('Registro Completado con Existo Nro de Denuncia '+this._complaint.FiscalCase, 'info', 'Mensaje');
            this.router.navigate(['/master/form-vw-listado/']);

          }
      });
  }
  doClicDrop($event)
  {
    debugger;
    console.log($event);
  }
  showMessage(mensaje, color, titulo) {

    this.msgs = [];
    this.msgs.push({ severity: color, summary: titulo, detail: mensaje });
}
}
