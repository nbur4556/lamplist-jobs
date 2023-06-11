import type { User } from '@src/store/AuthStore';
import { JobListStore } from '@src/store/JobListStore';

import type { StoreSetter } from '../types';

const logoutUser = (set: StoreSetter<User>) => {
  JobListStore.emptyStore();
  set({});
}

export default logoutUser;