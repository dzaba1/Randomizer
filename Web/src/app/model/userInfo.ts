import { NamedNavigation } from './navigation';
import { TokenData } from './tokenData';

export class UserInfo {
    public user: NamedNavigation<number>;
    public tokenData: TokenData;
}
