import type { JobEntry } from '@src/store/JobListStore';

import type { StoreUpdater } from './types';

const updateJobEntries = async (id: number, entry: Partial<JobEntry>, update: StoreUpdater) => {
	try {
		const result = await fetch(`http://localhost:5000/api/joblist/${id}`, {
			method: 'PATCH',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(entry)
		});
		const response = await result.json();
		update((state) => {
			state[id] = { ...state[id], ...response };
			return state;
		});
	} catch (err) {
		//TODO: Error Handling
		console.error(err);
	}
};

export default updateJobEntries;
