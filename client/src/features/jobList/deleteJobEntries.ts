import { PUBLIC_API_URL } from '$env/static/public';
import { get } from 'svelte/store';

import { AuthStore } from '@src/store/AuthStore';
import type { JobEntry } from '@src/store/JobListStore';

import type { StoreUpdater } from '../types';

const deleteJobEntries = async (id: string, update: StoreUpdater<JobEntry[]>) => {
	const authorizedUser = get(AuthStore);

	try {
		await fetch(`${PUBLIC_API_URL}/api/joblist/${id}`, {
			method: 'DELETE',
			headers: {
				Authorization: `Bearer ${authorizedUser.token}`
			}
		});
		update((state) => state.filter((val) => val.id !== id));
	} catch (err) {
		console.error(err);
	}
};

export default deleteJobEntries;
