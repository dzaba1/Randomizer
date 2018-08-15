export class CheckBoxViewModel {
    public value: boolean;
    public indeterminate: boolean;

    public setValue(value: boolean) {
        if (value == null) {
            this.indeterminate = true;
        } else {
            this.value = value;
            this.indeterminate = false;
        }
    }
}
