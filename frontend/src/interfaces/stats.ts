export interface IStats {
  readonly statsId: number;
  readonly userId: number;
  readonly kills: number;
  readonly deaths: number;
  readonly killDeathRatio: number;
  readonly wins: number;
  readonly losses: number;
  readonly winLossRatio: number;
}
