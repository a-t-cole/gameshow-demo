import { IntDictionary } from "./generic.models";

export interface BaseQuestion {
  IsAnswered: boolean; 
}
export interface ConnectionItem {
  Name: string;
  Postition: number;
  ImageURL: string;
}
export interface WallConnectionItem extends ConnectionItem{
  IsSelected: boolean; 
}

export enum ConnectionType {
  CONNECTION = 1,
  SEQUENCE = 2
}

export interface ConnectionQuestion extends BaseQuestion {
  Steps: IntDictionary<ConnectionItem>; 
  Answer: string;
  QuestionType: ConnectionType;
}

export interface MissingVowelItem {
  Question: string;
  Answer: string;
}
export interface MissingVowelCategory {
  Questions: MissingVowelItem[];
  CategoryName: string;
}
export interface WallGroup extends BaseQuestion {
  Items: WallConnectionItem[];
  Connection: string;

}

export interface ConnectionRound {
  Qestions: IntDictionary<ConnectionQuestion>;
}
export interface MissingVowelRound {
  Categories: MissingVowelCategory[];
}
export interface WallRound {
  Wall1: WallGroup[];
  Wall2: WallGroup[];
}

export interface Game {
  Id: number;
  Round1: ConnectionRound;
  Round2: ConnectionRound;
  Round3: WallRound;
  Round4: MissingVowelRound;
}