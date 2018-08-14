import hub from './hub';
import { signalRCommands as userSignalRCommands } from './actions/user';
import { signalRCommands as killFeedSignalRCommands } from './actions/killFeed';
import { Store } from 'redux';

enum HubMethod {
  OnConnected = 'OnConnected',
  OnDisconnected = 'OnDisconnected'
}

export const registerCommands = async (store: Store, cb: () => void) => {
  hub.on(HubMethod.OnConnected, connectionId => console.log(`${connectionId} has connected to SignalR Hub.`));
  hub.on(HubMethod.OnDisconnected, connectionId => console.log(`${connectionId} has disconnected from SignalR Hub.`));

  userSignalRCommands(store);
  killFeedSignalRCommands(store);

  await hub.start();
  cb();
};
