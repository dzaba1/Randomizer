import { Injectable } from '@angular/core';
import { NotifierService } from 'angular-notifier';
import { Require } from '../../utils/require';

export enum NotificationType {
  Default, Success, Info, Warning, Error
}

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private notifierService: NotifierService) { }

  public show(msg: string, type: NotificationType) {
    Require.notEmptyString(msg, 'msg');
    Require.notNull(type, 'type');

    this.notifierService.notify(this.toType(type), msg);
  }

  private toType(type: NotificationType): string {
    switch (type) {
      case NotificationType.Default:
        return 'default';
      case NotificationType.Error:
        return 'error';
      case NotificationType.Info:
        return 'info';
      case NotificationType.Success:
        return 'success';
      case NotificationType.Warning:
        return 'warning';
    }

    throw new RangeError(`Unknown type: ${type}`);
  }
}
