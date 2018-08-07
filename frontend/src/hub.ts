import * as SignalR from '@aspnet/signalr';

const connection = new SignalR.HubConnectionBuilder().withUrl('http://localhost:60930/signalrCounter').build();

export default connection;
