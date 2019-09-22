import { ModelBase } from './base.model';

export class Cat extends ModelBase<Cat>{
    public score: number;
    public url: string;
}