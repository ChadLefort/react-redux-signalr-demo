import { Attacker } from '../enums/attackers';
import { Defender } from '../enums/defenders';

export interface IKillFeed {
  killFeedId: number;
  matchId: number;
  userId: number;
  killFeedItems: IKillFeedItem[];
}

interface IKillFeedItem {
  killFeedItemId: number;
  killFeedId: number;
  kill: IKill;
  death: IDeath;
}

interface IDeath {
  deathUserId: number;
  killFeedItemId: number;
  username: string;
  operator: Attacker | Defender;
}

interface IKill {
  killUserId: number;
  killFeedItemId: number;
  username: string;
  operator: string;
}
