﻿//
//  MyClass.cs
//
//  Author:
//       Shawn L. Djernes <sdjernes@gmail.com>
//
//  Copyright (c) 2014 Shawn L. Djernes & SD Consulting LLC All Rights Reserved
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json;
using Mineboss.LibMiner;

namespace MineBoss.LibCGminer
{
    public class CGminer
    {
        private string _port = "4028";

        private string _hostname = "localhost";

        public string port
        {
            get
            {
                return this._port;
            }
            set
            {
                this._port = port;
            }
        }

        public string hostname
        {
            get {return this._hostname;}
            set {this._hostname = hostname;}
        }

        //TODO: Create Status Enumerator
        /*
         *   STATUS=X Where X is one of:
         *      W - Warning
         *      I - Informational
         *      S - Success
         *      E - Error
         *      F - Fatal (code bug)
        */

        #region Constructor
        public CGminer(string hostname, string port)
        {
            this.hostname = hostname;
            this.port = port;
        }

        public CGminer()
        {

        }
        #endregion

#region version
        /* CMD: version
         * RET: VERSION
         * MSG: CGMiner=cgminer version API=API| version
         */
        public string version()
        {
            string c = "version";
            string r = null;
            return r;
        }
#endregion

#region config
        /* CMD: config
         * RET: CONFIG
         * DESC: Some miner configuration information
         * ITEMS Returned:
         * ASC Count=N, <- the number of ASCs
         * PGA Count=N, <- the number of PGAs
         * Pool Count=N, <- the number of Pools
         * Strategy=Name, <- the current pool strategy
         * Log Interval=N, <- log interval (--log N)
         * Device Code=ICA , <- spaced list of compiled device drivers
         * OS=Linux/Apple/..., <- operating System
         * Failover-Only=true/false, <- failover-only setting
         * ScanTime=N, <- --scan-time setting
         * Queue=N, <- --queue setting
         * Expiry=N| <- --expiry setting
         */
        public string config()
        {
            string c = "config";
            string r = null;
            return r;
        }

#endregion
//            summary       SUMMARY        The status summary of the miner
//            e.g. Elapsed=NNN,Found Blocks=N,Getworks=N,...|
//
        #region
        /* CMD: pools
         * RET: POOLS
         * DESC: The status of each pool
         */
        public List<Pool> pools()
        {
            string c = "pools";
            List<Pool> p = null;
            return p;
        }
        #endregion
//            devs          DEVS           Each available PGA and ASC with their details
//            e.g. ASC=0,Accepted=NN,MHS av=NNN,...,Intensity=D|
//            Last Share Time=NNN, <- standand long time in sec
//        (or 0 if none) of last accepted share
//        Last Share Pool=N, <- pool number (or -1 if none)
//        Last Valid Work=NNN, <- standand long time in sec
//        of last work returned that wasn't an HW:
//        Will not report PGAs if PGA mining is disabled
//        Will not report ASCs if ASC mining is disabled
//
//            edevs[|old]   DEVS           The same as devs, except it ignores blacklisted
//            devices and zombie devices
//            If you specify the optional 'old' parameter, then
//            the output will include zombie devices that became
//            zombies less than 'old' seconds ago
//            A value of zero for 'old', which is the default,
//                means ignore all zombies
//                It will return an empty list of devices if all
//                    devices are blacklisted or zombies
//
//                    pga|N         PGA            The details of a single PGA number N in the same
//                    format and details as for DEVS
//                        This is only available if PGA mining is enabled
//                        Use 'pgacount' or 'config' first to see if there
//                            are any
//
//                            pgacount      PGAS           Count=N| <- the number of PGAs
//                                Always returns 0 if PGA mining is disabled
//
//                                    switchpool|N (*)
//                                    none           There is no reply section just the STATUS section
//                                    stating the results of switching pool N to the
//                                    highest priority (the pool is also enabled)
//                                    The Msg includes the pool URL
//
//                                    enablepool|N (*)
//                                    none           There is no reply section just the STATUS section
//                                    stating the results of enabling pool N
//                                    The Msg includes the pool URL
//
//                                    addpool|URL,USR,PASS (*)
//                                none           There is no reply section just the STATUS section
//                                stating the results of attempting to add pool N
//                                The Msg includes the pool URL
//                                Use '\\' to get a '\' and '\,' to include a comma
//                                inside URL, USR or PASS
//
//                                poolpriority|N,... (*)
//                                none           There is no reply section just the STATUS section
//                                stating the results of changing pool priorities
//                                See usage below
//
//                                poolquota|N,Q (*)
//                                none           There is no reply section just the STATUS section
//                                stating the results of changing pool quota to Q
//
//                                disablepool|N (*)
//                                none           There is no reply section just the STATUS section
//                                stating the results of disabling pool N
//                                The Msg includes the pool URL
//
//                                removepool|N (*)
//                                none           There is no reply section just the STATUS section
//                                stating the results of removing pool N
//                                The Msg includes the pool URL
//                                N.B. all details for the pool will be lost
//
//                                    save|filename (*)
//                                    none           There is no reply section just the STATUS section
//                                    stating success or failure saving the cgminer
//                                    config to filename
//                                    The filename is optional and will use the cgminer
//                                    default if not specified
//
//                                        quit (*)      none           There is no status section but just a single "BYE"
//                                        reply before cgminer quits
//
//                                        notify        NOTIFY         The last status and history count of each devices
//                                        problem
//                                        This lists all devices including those not
//                                        supported by the 'devs' command e.g.
//                                        NOTIFY=0,Name=ASC,ID=0,Last Well=1332432290,...|
//
//        privileged (*)
//        none           There is no reply section just the STATUS section
//        stating an error if you do not have privileged
//            access to the API and success if you do have
//                privilege
//                The command doesn't change anything in cgminer
//
//                pgaenable|N (*)
//                none           There is no reply section just the STATUS section
//                stating the results of the enable request
//                You cannot enable a PGA if it's status is not WELL
//                This is only available if PGA mining is enabled
//
//                    pgadisable|N (*)
//                    none           There is no reply section just the STATUS section
//                    stating the results of the disable request
//                This is only available if PGA mining is enabled
//
//                    pgaidentify|N (*)
//                    none           There is no reply section just the STATUS section
//                    stating the results of the identify request
//                This is only available if PGA mining is enabled
//                    and currently only BFL singles and Cairnsmore1's
//                    with the appropriate firmware support this command
//                    On a BFL single it will flash the led on the front
//                    of the device for appoximately 4s
//                        All other non BFL,ICA PGA devices will return a
//                            warning status message stating that they dont
//                            support it. Non-CMR ICAs will ignore the command.
//                            This adds a 4s delay to the BFL share being
//                            processed so you may get a message stating that
//                            procssing took longer than 7000ms if the request
//                                was sent towards the end of the timing of any work
//                                being worked on
//                                e.g.: BFL0: took 8438ms - longer than 7000ms
//                                You should ignore this
//
//                                devdetails    DEVDETAILS     Each device with a list of their static details
//                                This lists all devices including those not
//                                supported by the 'devs' command
//                                e.g. DEVDETAILS=0,Name=ASC,ID=0,Driver=yuu,...|
//
//        restart (*)   none           There is no status section but just a single
//        "RESTART" reply before cgminer restarts
//
//        stats         STATS          Each device or pool that has 1 or more getworks
//        with a list of stats regarding getwork times
//        The values returned by stats may change in future
//        versions thus would not normally be displayed
//        Device drivers are also able to add stats to the
//        end of the details returned
//
//        estats[|old]  STATS          The same as stats, except it ignores blacklisted
//        devices, zombie devices and pools
//        If you specify the optional 'old' parameter, then
//        the output will include zombie devices that became
//        zombies less than 'old' seconds ago
//        A value of zero for 'old', which is the default,
//            means ignore all zombies
//            It will return an empty list of devices if all
//                devices are blacklisted or zombies
//
//                check|cmd     COMMAND        Exists=Y/N, <- 'cmd' exists in this version
//        Access=Y/N| <- you have access to use 'cmd'
//
//            failover-only|true/false (*)
//            none           There is no reply section just the STATUS section
//            stating what failover-only was set to
//
//            coin          COIN           Coin mining information:
//            Hash Method=sha256/scrypt,
//        Current Block Time=N.N, <- 0 means none
//        Current Block Hash=XXXX..., <- blank if none
//            LP=true/false, <- LP is in use on at least 1 pool
//        Network Difficulty=NN.NN|
//
//            debug|setting (*)
//            DEBUG          Debug settings
//            The optional commands for 'setting' are the same
//                as the screen curses debug settings
//                You can only specify one setting
//                Only the first character is checked - case
//                insensitive:
//                Silent, Quiet, Verbose, Debug, RPCProto,
//            PerDevice, WorkTime, Normal
//            The output fields are (as above):
//            Silent=true/false,
//        Quiet=true/false,
//        Verbose=true/false,
//        Debug=true/false,
//        RPCProto=true/false,
//        PerDevice=true/false,
//        WorkTime=true/false|
//
//            setconfig|name,N (*)
//        none           There is no reply section just the STATUS section
//        stating the results of setting 'name' to N
//        The valid values for name are currently:
//            queue, scantime, expiry
//            N is an integer in the range 0 to 9999
//
//            usbstats      USBSTATS       Stats of all LIBUSB mining devices except ztex
//            e.g. Name=MMQ,ID=0,Stat=SendWork,Count=99,...|
//
//        pgaset|N,opt[,val] (*)
//        none           There is no reply section just the STATUS section
//        stating the results of setting PGA N with
//        opt[,val]
//        This is only available if PGA mining is enabled
//
//            If the PGA does not support any set options, it
//            will always return a WARN stating pgaset isn't
//                supported
//
//                If opt=help it will return an INFO status with a
//                    help message about the options available
//
//                    The current options are:
//                    MMQ opt=clock val=160 to 230 (a multiple of 2)
//                    CMR opt=clock val=100 to 220
//
//                    zero|Which,true/false (*)
//        none           There is no reply section just the STATUS section
//        stating that the zero, and optional summary, was
//        done
//        If Which='all', all normal cgminer and API
//        statistics will be zeroed other than the numbers
//        displayed by the usbstats and stats commands
//        If Which='bestshare', only the 'Best Share' values
//        are zeroed for each pool and the global
//            'Best Share'
//            The true/false option determines if a full summary
//                is shown on the cgminer display like is normally
//                displayed on exit.
//
//                hotplug|N (*) none           There is no reply section just the STATUS section
//                stating that the hotplug setting succeeded
//                If the code is not compiled with hotplug in it,
//                the the warning reply will be
//                'Hotplug is not available'
//                If N=0 then hotplug will be disabled
//                    If N>0 && <=9999, then hotplug will check for new
//            devices every N seconds
//
//            asc|N         ASC            The details of a single ASC number N in the same
//            format and details as for DEVS
//                This is only available if ASC mining is enabled
//                Use 'asccount' or 'config' first to see if there
//                    are any
//
//                    ascenable|N (*)
//                    none           There is no reply section just the STATUS section
//                    stating the results of the enable request
//                You cannot enable a ASC if it's status is not WELL
//                This is only available if ASC mining is enabled
//
//                    ascdisable|N (*)
//                    none           There is no reply section just the STATUS section
//                    stating the results of the disable request
//                This is only available if ASC mining is enabled
//
//                    ascidentify|N (*)
//                    none           There is no reply section just the STATUS section
//                    stating the results of the identify request
//                This is only available if ASC mining is enabled
//                    and currently only BFL ASICs support this command
//                    On a BFL single it will flash the led on the front
//                    of the device for appoximately 4s
//                        All other non BFL ASIC devices will return a
//                            warning status message stating that they dont
//                            support it
//
//                            asccount      ASCS           Count=N| <- the number of ASCs
//                                Always returns 0 if ASC mining is disabled
//
//                                    ascset|N,opt[,val] (*)
//                                none           There is no reply section just the STATUS section
//                                stating the results of setting ASC N with
//                                opt[,val]
//                                This is only available if ASC mining is enabled
//
//                                    If the ASC does not support any set options, it
//                                    will always return a WARN stating ascset isn't
//                                        supported
//
//                                        If opt=help it will return an INFO status with a
//                                            help message about the options available
//
//                                            The current options are:
//                                            AVA+BTB opt=freq val=256 to 1024 - chip frequency
//                                            BTB opt=millivolts val=1000 to 1400 - corevoltage
//
//                                            lcd           LCD            An all-in-one short status summary of the miner
//                                            e.g. Elapsed,GHS av,GHS 5m,GHS 5s,Temp,
//                                Last Share Difficulty,Last Share Time,
//                                Best Share,Last Valid Work,Found Blocks,
//                                Pool,User|
//
//                                lockstats (*) none           There is no reply section just the STATUS section
//                                stating the results of the request
//                                A warning reply means lock stats are not compiled
//                                    into cgminer
//                                The API writes all the lock stats to stderr


    }
}

