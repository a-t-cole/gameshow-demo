
export interface IGenericKeyValuePair<K, V>{
    Key: K; 
    Value: V; 
}

export class GenericKeyValuePair<K,V> implements IGenericKeyValuePair<K, V>{
    constructor(key: K, value: V){
        this.Key = key; 
        this.Value = value; 
    }
    Key: K;
    Value: V;
}

export interface StringDictionary<T>{
    [index: string] : T; 
}

export interface IntDictionary<T>{
    [index: number] : T; 
}