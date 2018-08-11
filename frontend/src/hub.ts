import * as SignalR from '@aspnet/signalr';

const connection = new SignalR.HubConnectionBuilder().withUrl('/r6stats').build();

export default connection;
