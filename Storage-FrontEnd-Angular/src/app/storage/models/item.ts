import { Action } from "./action";

export interface Item {
  name: string;
  quantity: number;
  unitValue: number;
  action: Action
}
