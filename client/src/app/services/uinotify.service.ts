import { Injectable } from '@angular/core';
import { ActiveToast, ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class UINotifyService {

  constructor(private toastrSvc: ToastrService) { }

  throwError(message: string):ActiveToast<any>{
      return message ? this.toastrSvc.error(message) : null;
  }

  throwSuccess(message: string):ActiveToast<any>{
    return message? this.toastrSvc.success(message) : null; 
  }

  toastInfo(message: string) : ActiveToast<any>{
    return message? this.toastrSvc.info(message) : null; 
  }
}
