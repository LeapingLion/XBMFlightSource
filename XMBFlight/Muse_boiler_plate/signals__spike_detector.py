import sys
import statistics
import os


def find_min_max_signals(relax_file):
    e0s, e1s, e2s, e3s = ([], [], [], [])
    file = open(relax_file, "r")
    line = file.readline()
    while line != "":
        line_list = line.split(",")
        e0s.append(float(line_list[0]))
        e1s.append(float(line_list[1]))
        e2s.append(float(line_list[2]))
        e3s.append(float(line_list[3]))
        line = file.readline()
    e_s = [e0s, e1s, e2s, e3s]
    min_max_signals = []
    for e in e_s:
        e_sd = statistics.stdev(e)
        e_av = statistics.mean(e)
        e_min_max = (e_av - e_sd, e_av + e_sd)
        min_max_signals.append(e_min_max)
    return min_max_signals


def getCurrentSignals(real_file):
    signals_str = input()
    signals = tuple(signals_str.split(","))
    return signals



def report_spikes(min_max_signals, signals):
    index = 0
    spike = False
    for signal in signals:
        min, max = min_max_signals[index]
        if (min > signal > max):
            return True
    return spike


def main():
    # Takes 2 command line arguments which are the muse signal files for "at rest" and "during gameplay"
    # Takes Action if a spike is detected.
    # relax_file, real_file = sys.argv[0], sys.argv[1]
    # min_max_signals = find_min_max_signals(relax_file)
    relax_file, real_file = "eeg_boiler_relax.csv", "eeg_boiler.csv"
    while True:
        signals = getCurrentSignals(real_file)
        spike = report_spikes(min_max_signals, signals)
        if spike:
            print("Triggered")


if __name__ == "__main__":
    main()


