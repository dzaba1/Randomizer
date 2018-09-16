import { Injectable } from '@angular/core';
import { Require } from '../../utils/require';
import { LoggingService } from './logging.service';
import { ToastrService, ActiveToast } from 'ngx-toastr';
import { Observable } from 'rxjs';

export enum NotificationType {
  Success, Info, Warning, Error
}

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private toastr: ToastrService,
    private logger: LoggingService) { }

  public show(msg: string, type: NotificationType): Observable<any> {
    Require.notEmptyString(msg, 'msg');
    Require.notNull(type, 'type');

    this.logger.debug(`Displaying notification '${msg}' of type '${type}'`);
    let toast: ActiveToast<any>;

    switch (type) {
      case NotificationType.Error:
        toast = this.toastr.error(msg);
        break;
      case NotificationType.Info:
        toast = this.toastr.info(msg);
        break;
      case NotificationType.Success:
        toast = this.toastr.success(msg);
        break;
      case NotificationType.Warning:
        toast = this.toastr.warning(msg);
        break;
      default: throw new RangeError(`Unknown type: '${type}'`);
    }

    return toast.onHidden;
  }
}
