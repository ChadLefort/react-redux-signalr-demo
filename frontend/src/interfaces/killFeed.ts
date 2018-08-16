import { Attacker } from '../enums/attackers';
import { Defender } from '../enums/defenders';

export interface IKillFeed {
  readonly killFeedId: number;
  readonly matchId: number;
  readonly userId: number;
  readonly killFeedItems: IKillFeedItem[];
}

export interface IKillFeedItem {
  readonly killFeedItemId: number;
  readonly killFeedId: number;
  readonly kill: IKill;
  readonly death: IDeath;
}

export interface IDeath {
  readonly deathUserId: number;
  readonly killFeedItemId: number;
  readonly username: string;
  readonly operator: Attacker | Defender;
}

export interface IKill {
  readonly killUserId: number;
  readonly killFeedItemId: number;
  readonly username: string;
  readonly operator: string;
}
