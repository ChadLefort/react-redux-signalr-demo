import { IStats } from './stats';

export interface IUser {
  readonly userId: number;
  readonly username: string;
  readonly stats: IStats;
}
