namespace Namespace {
    
    using sys;
    
    using statistics;
    
    using os;
    
    using System.Collections.Generic;
    
    public static class Module {
        
        public static object find_min_max_signals(object relax_file) {
            var _tup_1 = (new List<object>(), new List<object>(), new List<object>(), new List<object>());
            var e0s = _tup_1.Item1;
            var e1s = _tup_1.Item2;
            var e2s = _tup_1.Item3;
            var e3s = _tup_1.Item4;
            var file = open(relax_file, "r");
            var line = file.readline();
            while (line != "") {
                var line_list = line.split(",");
                e0s.append(float(line_list[0]));
                e1s.append(float(line_list[1]));
                e2s.append(float(line_list[2]));
                e3s.append(float(line_list[3]));
                line = file.readline();
            }
            var e_s = new List<object> {
                e0s,
                e1s,
                e2s,
                e3s
            };
            var min_max_signals = new List<object>();
            foreach (var e in e_s) {
                var e_sd = statistics.stdev(e);
                var e_av = statistics.mean(e);
                var e_min_max = (e_av - e_sd, e_av + e_sd);
                min_max_signals.append(e_min_max);
            }
            return min_max_signals;
        }
        
        public static object getCurrentSignals(object real_file) {
            var signals_str = input();
            var signals = tuple(signals_str.split(","));
            return signals;
        }
        
        public static object report_spikes(object min_max_signals, object signals) {
            var index = 0;
            var spike = false;
            foreach (var signal in signals) {
                var _tup_1 = min_max_signals[index];
                var min = _tup_1.Item1;
                var max = _tup_1.Item2;
                if (min > signal > max) {
                    return true;
                }
            }
            return spike;
        }
        
        public static object main() {
            // Takes 2 command line arguments which are the muse signal files for "at rest" and "during gameplay"
            // Takes Action if a spike is detected.
            // relax_file, real_file = sys.argv[0], sys.argv[1]
            // min_max_signals = find_min_max_signals(relax_file)
            var relax_file = "eeg_boiler_relax.csv";
            var real_file = "eeg_boiler.csv";
            while (true) {
                var signals = getCurrentSignals(real_file);
                var spike = report_spikes(min_max_signals, signals);
                if (spike) {
                    Console.WriteLine("Triggered");
                }
            }
        }
        
        static Module() {
            main();
        }
    }
}
