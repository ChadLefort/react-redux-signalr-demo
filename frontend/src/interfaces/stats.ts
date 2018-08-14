import { Attacker } from '../enums/attackers';
import { Defender } from '../enums/defenders';

export interface IStats {
  readonly statsId: number;
  readonly userId: number;
  readonly kills: number;
  readonly deaths: number;
  readonly killDeathRatio: number;
  readonly wins: number;
  readonly losses: number;
  readonly rank: string;
  readonly topAttacker: Attacker;
  readonly topDefender: Defender;
  readonly winLossRatio: number;
}
