import { Injectable } from '@angular/core';
import { NotifierService } from 'angular-notifier';
import { Require } from '../../utils/require';
import { LoggingService } from './logging.service';

export enum NotificationType {
  Default, Success, Info, Warning, Error
}

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private notifierService: NotifierService,
    private logger: LoggingService) { }

  public show(msg: string, type: NotificationType) {
    Require.notEmptyString(msg, 'msg');
    Require.notNull(type, 'type');

    const typeStr = this.toType(type);
    this.logger.debug(`Displaying notification '${msg}' of type '${typeStr}'`);
    this.notifierService.notify(typeStr, msg);
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
