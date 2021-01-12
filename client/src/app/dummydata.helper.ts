import { WallGroup } from "./models/questions.models";

export abstract class DummyData{

  static getWallGroup():WallGroup[]{

    let result: WallGroup[] = []; 
    for(let i = 0; i < 4; i++){
      let group: WallGroup = {
        Connection: `Connection Group ${i}`, 
        Items: [], 
        IsAnswered: false, 
        GroupId: i
      }; 
      for(let j = 0; j < 4; j++){
        group.Items.push({
          ImageURL: '', 
          Name: `Group: ${i}-${j}`, 
          Postition: j, 
          IsSelected: false, 
          GroupId: i
        })
      }
      result.push(group);
    } 
    return result; 
  }
}