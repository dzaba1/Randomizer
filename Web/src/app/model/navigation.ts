export class Navigation<T> {
    public id: T;
    public url: string;
}

export class NamedNavigation<T> extends Navigation<T> {
    public name: string;
}
