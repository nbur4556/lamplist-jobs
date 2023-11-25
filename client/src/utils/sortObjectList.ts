const compareVal = <T>(a: T, b: T, reversed: boolean) => {
	if(!a) {
		return false;
	}
	if(!b) {
		return true;
	}

	return reversed ? a > b : a < b;
};

//TODO: thoroughly test this function
const sortObjectList = <T>(list: Array<T>, term: keyof T, reversed: boolean): Array<T> => {
	type V = T[typeof term];
	let sortedList: Array<T> = [];
	list.forEach((entry) => {
		for (let i = 0; i < sortedList.length; i++) {
			if (compareVal<V>(entry[term], sortedList[i][term], reversed)) {
				sortedList = [...sortedList.slice(0, i), entry, ...sortedList.slice(i, sortedList.length)];
				return;
			}
		}
		sortedList = [...sortedList, entry];
	});
	return sortedList;
};

export default sortObjectList;
