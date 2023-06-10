import { PUBLIC_API_URL } from '$env/static/public';
import {get} from 'svelte/store'

import { AuthStore } from '@src/store/AuthStore';
import type { JobEntry } from '@src/store/JobListStore';

import type { StoreUpdater } from '../types';

const fetchJobEntries = async (update: StoreUpdater<JobEntry[]>) => {
  const authorizedUser = get(AuthStore);

	try {
		const response = await (await fetch(`${PUBLIC_API_URL}/api/joblist`, {
      headers: {
        "Authorization": `Bearer ${authorizedUser.token}`,
      }
    })).json();
		update(() => response);
	} catch (err) {
		console.error(err);
	}
};

export default fetchJobEntries;
