import { PUBLIC_API_URL } from '$env/static/public';

import type { StoreUpdater } from './types';

const deleteJobEntries = async (id: string, update: StoreUpdater) => {
	try {
		await fetch(`${PUBLIC_API_URL}/api/joblist/${id}`, {
			method: 'DELETE'
		});
		update((state) => state.filter((val) => val.id !== id));
	} catch (err) {
		//TODO: Error Handling
		console.error(err);
	}
};

export default deleteJobEntries;
